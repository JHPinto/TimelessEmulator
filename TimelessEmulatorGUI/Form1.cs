using System.Collections;
using TimelessLib.Data;
using TimelessLib.Data.Models;
using TimelessLib.Game;

namespace TimelessEmulatorGUI
{
    public partial class Form1 : Form
    {
        private uint alternateTreeVersionIndex;
        private TimelessJewelConqueror timelessJewelConqueror;
        private HashSet<PassiveSkill> selectedPassiveSkills = new HashSet<PassiveSkill>();
        private static Dictionary<uint, string> timelessJewelTypes = new Dictionary<uint, string>()
        {
            { 1, "Glorious Vanity" },
            { 2, "Lethal Pride" },
            { 3, "Brutal Restraint" },
            { 4, "Militant Faith" },
            { 5, "Elegant Hubris" }
        };
        private static Dictionary<uint, (uint minimumSeed, uint maximumSeed)> timelessJewelSeedRanges = new Dictionary<uint, (uint minimumSeed, uint maximumSeed)>()
        {
            { 1, (100, 8000) },
            { 2, (10000, 18000) },
            { 3, (500, 8000) },
            { 4, (2000, 10000) },
            { 5, (2000, 160000) }
        };
        private static Dictionary<uint, Dictionary<string, TimelessJewelConqueror>> timelessJewelConquerors = new Dictionary<uint, Dictionary<string, TimelessJewelConqueror>>()
        {
            {
                1, new Dictionary<string, TimelessJewelConqueror>()
                {
                    { "Xibaqua", new TimelessJewelConqueror(1, 0) },
                    { "Zerphi (Legacy)", new TimelessJewelConqueror(2, 0) },
                    { "Ahuana", new TimelessJewelConqueror(2, 1) },
                    { "Doryani", new TimelessJewelConqueror(3, 0) }
                }
            },
            {
                2, new Dictionary<string, TimelessJewelConqueror>()
                {
                    { "Kaom", new TimelessJewelConqueror(1, 0) },
                    { "Rakiata", new TimelessJewelConqueror(2, 0) },
                    { "Kiloava (Legacy)", new TimelessJewelConqueror(3, 0) },
                    { "Akoya", new TimelessJewelConqueror(3, 1) }
                }
            },
            {
                3, new Dictionary<string, TimelessJewelConqueror>()
                {
                    { "Deshret (Legacy)", new TimelessJewelConqueror(1, 0) },
                    { "Balbala", new TimelessJewelConqueror(1, 1) },
                    { "Asenath", new TimelessJewelConqueror(2, 0) },
                    { "Nasima", new TimelessJewelConqueror(3, 0) }
                }
            },
            {
                4, new Dictionary<string, TimelessJewelConqueror>()
                {
                    { "Venarius (Legacy)", new TimelessJewelConqueror(1, 0) },
                    { "Maxarius", new TimelessJewelConqueror(1, 1) },
                    { "Dominus", new TimelessJewelConqueror(2, 0) },
                    { "Avarius", new TimelessJewelConqueror(3, 0) }
                }
            },
            {
                5, new Dictionary<string, TimelessJewelConqueror>()
                {
                    { "Cadiro", new TimelessJewelConqueror(1, 0) },
                    { "Victario", new TimelessJewelConqueror(2, 0) },
                    { "Chitus (Legacy)", new TimelessJewelConqueror(3, 0) },
                    { "Caspiro", new TimelessJewelConqueror(3, 1) }
                }
            }
        };
        public Form1()
        {
            if (!DataManager.Initialize())
                throw new Exception();
            InitializeComponent();
            this.jewelTypeSelection.Items.AddRange(timelessJewelTypes.Values.ToArray());
            keystoneTypeSelection.Enabled = false;
            desiredStatCombo.Enabled = false;
            generateButton.Enabled = false;
            foreach (PassiveSkill skill in DataManager.PassiveSkills)
            {
                if(skill.IsNotable)
                    this.selectedSkills.Items.Add(skill.Name, false);
            }
        }

        private void jewelTypeSelection_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox senderComboBox = (ComboBox)sender;
            if (senderComboBox.SelectedItem == null)
            {
                keystoneTypeSelection.Enabled = false;
                desiredStatCombo.Enabled = false;
            }
            keystoneTypeSelection.Enabled = true;
            keystoneTypeSelection.Text = "";
            desiredStatCombo.Text = "";
            alternateTreeVersionIndex = timelessJewelTypes
            .First(q => (q.Value == senderComboBox.SelectedItem.ToString()))
            .Key;
            this.keystoneTypeSelection.Items.Clear();
            this.keystoneTypeSelection.Items.AddRange(timelessJewelConquerors[alternateTreeVersionIndex].Keys.ToArray());
        }

        private void keystoneTypeSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox senderComboBox = (ComboBox)sender;
            if (senderComboBox.SelectedItem == null)
            {
                desiredStatCombo.Enabled = false;
            }
            desiredStatCombo.Enabled = true;
            timelessJewelConqueror = timelessJewelConquerors[alternateTreeVersionIndex][senderComboBox.SelectedItem.ToString()];
            desiredStatCombo.Items.Clear();
            desiredStatCombo.Items.AddRange(DataManager.AlternatePassiveSkills.Where(apa => apa.ApplicablePassiveTypes.ToList().Contains((uint)PassiveSkillType.Notable) && apa.AlternateTreeVersionIndex == alternateTreeVersionIndex).Select(s => s.Name).Distinct().ToArray());
            desiredStatCombo.Items.AddRange(DataManager.AlternatePassiveAdditions.Where(apa => apa.ApplicablePassiveTypes.ToList().Contains((uint)PassiveSkillType.Notable) && apa.AlternateTreeVersionIndex == alternateTreeVersionIndex).Select(s => String.Concat(s.StatIndices.Select(idx => DataManager.GetStatIdentifierByIndex(idx)))).ToArray());
        }

        private void skillFilter_TextChanged(object sender, EventArgs e)
        {
            TextBox textFilterBox = (TextBox)sender;
            this.selectedSkills.Items.Clear();
            List<object> list = new List<object>();
            foreach (PassiveSkill skill in DataManager.PassiveSkills)
            {
                if (skill.IsNotable && skill.Name.ToLower().Contains(textFilterBox.Text))
                    this.selectedSkills.Items.Add(skill.Name, selectedPassiveSkills.Any(sps => sps.Name == skill.Name));
            }
        }

        private void selectedSkills_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Unchecked)
                selectedPassiveSkills.Remove(DataManager.PassiveSkills.First(p => p.Name == selectedSkills.Items[e.Index].ToString()));
            else
                selectedPassiveSkills.Add(DataManager.PassiveSkills.First(p => p.Name == selectedSkills.Items[e.Index].ToString()));
            
            DisplayWarningText();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (desiredStatCombo.SelectedItem != null)
                desiredStatList.Items.Add(desiredStatCombo.SelectedItem);
            DisplayWarningText();
        }

        private void desiredStatList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.desiredStatList.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                desiredStatList.Items.RemoveAt(index);
            }
            DisplayWarningText();
        }

        private void DisplayWarningText()
        {
            if (desiredStatList.Items.Count > selectedPassiveSkills.Count)
            {
                warningText.Text = $"Warning: you have selected more desired outcomes ({desiredStatList.Items.Count}) than selected target skills ({selectedPassiveSkills.Count}).";
                generateButton.Enabled = false;
            }
            else
            {
                warningText.Text = "";
                generateButton.Enabled = true;
            }
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            this.bruteforceProgress.Minimum = (int)timelessJewelSeedRanges[alternateTreeVersionIndex].minimumSeed;
            this.bruteforceProgress.Maximum = (int)timelessJewelSeedRanges[alternateTreeVersionIndex].maximumSeed + 1;
            this.bruteforceProgress.Value = (int)timelessJewelSeedRanges[alternateTreeVersionIndex].minimumSeed;
            this.bruteforceProgress.Enabled = true;
            this.bruteforceProgress.Step = 1;
            validJewels.Items.Clear();
            Dictionary<string, uint> desiredStatCounts = new Dictionary<string, uint>();
            foreach(string desiredStat in this.desiredStatList.Items)
            {
                if(desiredStatCounts.ContainsKey(desiredStat)) {
                    desiredStatCounts[desiredStat]++;
                } else
                {
                    desiredStatCounts.Add(desiredStat, 1);
                }
            }
            uint increment = 1;
            if(alternateTreeVersionIndex == 5)
            {
                increment = 20;
                this.bruteforceProgress.Step = 20;
            }
            for (uint i = timelessJewelSeedRanges[alternateTreeVersionIndex].minimumSeed; i <= timelessJewelSeedRanges[alternateTreeVersionIndex].maximumSeed; i+=increment)
            {
                Dictionary<string, uint> matches = new Dictionary<string, uint>();
                TimelessJewel timelessJewel = new TimelessJewel(DataManager.AlternateTreeVersions.First(q => (q.Index == alternateTreeVersionIndex)), timelessJewelConqueror, i);
                foreach (PassiveSkill passiveSkill in selectedPassiveSkills)
                {
                    AlternateTreeManager alternateTreeManager = new AlternateTreeManager(passiveSkill, timelessJewel);

                    bool isPassiveSkillReplaced = alternateTreeManager.IsPassiveSkillReplaced();
                    if (isPassiveSkillReplaced)
                    {
                        AlternatePassiveSkillInformation alternatePassiveSkillInformation = alternateTreeManager.ReplacePassiveSkill();
                        if (matches.ContainsKey(alternatePassiveSkillInformation.AlternatePassiveSkill.Name))
                        {
                            matches[alternatePassiveSkillInformation.AlternatePassiveSkill.Name]++;
                        } else
                        {
                            matches.Add(alternatePassiveSkillInformation.AlternatePassiveSkill.Name, 1);
                        }
                    }
                    else
                    {
                        IReadOnlyCollection<AlternatePassiveAdditionInformation> alternatePassiveAdditionInformations = alternateTreeManager.AugmentPassiveSkill();
                        foreach (var alternatePassiveSkill in alternatePassiveAdditionInformations)
                        {
                            string addedName = String.Concat(alternatePassiveSkill.AlternatePassiveAddition.StatIndices.Select(idx => DataManager.GetStatIdentifierByIndex(idx)));
                            if (matches.ContainsKey(addedName))
                            {
                                matches[addedName]++;
                            }
                            else
                            {
                                matches.Add(addedName, 1);
                            }
                        }
                    }
                }
                bool matched = true;
                foreach (var desiredMatch in desiredStatCounts)
                {
                    if(!matches.ContainsKey(desiredMatch.Key))
                    {
                        matched = false;
                        break;
                    }
                    if(matches[desiredMatch.Key] < desiredMatch.Value)
                    {
                        matched = false;
                        break;
                    }
                }
                if (matched)
                {
                    validJewels.Items.Add(i);
                }
                this.bruteforceProgress.PerformStep();
            }

            this.bruteforceProgress.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}