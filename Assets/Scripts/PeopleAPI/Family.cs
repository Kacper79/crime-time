using System.Collections.Generic;
using UnityEngine;
public class Family : MonoBehaviour
{
    public List<Person> firstGeneration;
    public List<Person> secondGeneration;
    public List<Person> thirdGeneration;
    public PeopleCreator creator;
    public System.Random random = new System.Random();
    public int[] keyCount;
    public Family continuationFamily;
    public void GenerateFamily()
    {
        //Generate 1st Generation- 4 main persons
        Person grandmotherof = creator.GeneratePersonalInfo();
        Person grandfatherof = creator.GeneratePersonalInfo();
        Person grandmotherom = creator.GeneratePersonalInfo();
        Person grandfatherom = creator.GeneratePersonalInfo();
        Person mother = creator.GeneratePersonalInfo();
        Person father = creator.GeneratePersonalInfo();
        Person son = creator.GeneratePersonalInfo();
        Person daughter = creator.GeneratePersonalInfo();
        grandmotherom.gender = 1;
        grandmotherof.gender = 1;
        grandfatherom.gender = 0;
        grandfatherof.gender = 0;
        father.gender = 0;
        mother.gender = 1;
        son.gender = 0;
        daughter.gender = 1;
        //Some kind of loop wou
        firstGeneration.Add(grandmotherof);
        firstGeneration.Add(grandfatherof);
        firstGeneration.Add(grandmotherom);
        firstGeneration.Add(grandfatherom);
        secondGeneration.Add(father);
        secondGeneration.Add(mother);
        thirdGeneration.Add(son);
        thirdGeneration.Add(daughter);
        //Generate more people if family is wealthy;
    }
    public void SplitHeirdomWithoutTestament(Person deadperson)
    {
        Person[] tmpl = new Person[4];
        int tmpi = 0;
        if (firstGeneration.Contains(deadperson))
        {
            foreach (Person p in secondGeneration)
            {
                if (p.wasCriminalAlready == false)
                {
                    tmpl[tmpi] = p;
                    tmpi++;
                }
            }
            if (tmpl[0] == null)
            {
                foreach (Person p1 in thirdGeneration)
                {
                    if (p1.wasCriminalAlready == false)
                    {
                        tmpl[tmpi] = p1;
                        tmpi++;
                    }
                }
                if (tmpl[0] == null)
                {
                    foreach (Person p in firstGeneration)
                    {
                        if (p.wasCriminalAlready == false)
                        {
                            tmpl[tmpi] = p;
                            tmpi++;
                        }
                    }
                    if (tmpl[0] == null)
                    {
                        int startIndex = 0;
                        foreach (BankAccount a in deadperson.bankAccounts)
                        {
                            if (!a.accountBlocked)
                            {
                                a.TransferMoneyTaxFree(GovermentAccounts.Instance.govAccount, "HS MTRANSFER FROM " + deadperson.ID, a.money);
                            }
                            else //else money is going to country black budget and military
                            {
                                startIndex++;
                            }


                        }
                        foreach (Asset a in deadperson.assetAccount.assets)
                        {
                            deadperson.assetAccount.TransferAssetTaxFree(GovermentAccounts.Instance.assetAccount, GovermentAccounts.Instance.govAccount, deadperson.bankAccounts[startIndex], 0, a);
                        }
                    }
                }
            }

        }
        if (secondGeneration.Contains(deadperson))
        {
            foreach (Person p in thirdGeneration)
            {
                if (p.wasCriminalAlready == false)
                {
                    tmpl[tmpi] = p;
                    tmpi++;
                }
                if (tmpl[0] == null)
                {
                    foreach (Person p1 in secondGeneration)
                    {
                        if (p1.wasCriminalAlready == false)
                        {
                            tmpl[tmpi] = p1;
                            tmpi++;
                        }
                    }
                    if (tmpl[0] == null)
                    {
                        foreach (Person p2 in firstGeneration)
                        {
                            if (p2.wasCriminalAlready == false)
                            {
                                tmpl[tmpi] = p2;
                                tmpi++;
                            }
                        }
                        if (tmpl[0] == null)
                        {
                            int startIndex = 0;
                            foreach(BankAccount a in deadperson.bankAccounts)
                            {
                                if (!a.accountBlocked)
                                {
                                    a.TransferMoneyTaxFree(GovermentAccounts.Instance.govAccount, "HS MTRANSFER FROM " + deadperson.ID, a.money);
                                }
                                else //else money is going to country black budget and military
                                {
                                    startIndex++;
                                }


                            }
                            foreach(Asset a in deadperson.assetAccount.assets)
                            {
                                deadperson.assetAccount.TransferAssetTaxFree(GovermentAccounts.Instance.assetAccount, GovermentAccounts.Instance.govAccount, deadperson.bankAccounts[startIndex], 0,a);
                            }

                        }
                    }
                }
            }
            if (thirdGeneration.Contains(deadperson))
            {
                foreach (Person p in thirdGeneration)
                {
                    if (p.wasCriminalAlready == false)
                    {
                        tmpl[tmpi] = p;
                        tmpi++;
                    }
                }
                if (tmpl[0] == null)
                {
                    foreach (Person p1 in secondGeneration)
                    {
                        if (p1.wasCriminalAlready == false)
                        {
                            tmpl[tmpi] = p1;
                            tmpi++;
                        }
                    }
                    if (tmpl[0] == null)
                    {
                        foreach (Person p2 in firstGeneration)
                        {
                            if (p2.wasCriminalAlready == false)
                            {
                                tmpl[tmpi] = p2;
                                tmpi++;
                            }
                        }
                        if (tmpl[0] == null)
                        {
                            int startIndex = 0;
                            foreach (BankAccount a in deadperson.bankAccounts)
                            {
                                if (!a.accountBlocked)
                                {
                                    a.TransferMoneyTaxFree(GovermentAccounts.Instance.govAccount, "HS MTRANSFER FROM " + deadperson.ID, a.money);
                                }
                                else //else money is going to country black budget and military
                                {
                                    startIndex++;
                                }


                            }
                            foreach (Asset a in deadperson.assetAccount.assets)
                            {
                                deadperson.assetAccount.TransferAssetTaxFree(GovermentAccounts.Instance.assetAccount, GovermentAccounts.Instance.govAccount, deadperson.bankAccounts[startIndex], 0, a);
                            }
                        }
                    }
                }

            }
        }
        if (tmpl[0] == null)
        {
            return;
        }
        float percent = 1 / tmpl.Length;
        foreach(BankAccount a in deadperson.bankAccounts)
        {
            for (int i = 0;i < tmpl.Length; i++)
            {
                int index = 0;
                foreach(BankAccount b in tmpl[i].bankAccounts)
                {
                    if (!b.accountBlocked)
                    {
                        break;
                    }
                    else
                    {
                        index++;
                    }
                }
                a.TransferMoneyTaxFree(tmpl[i].bankAccounts[index],"HS MTRANSFER FROM "+deadperson.ID,(int)(a.money*percent));
            }

        }
        int split = deadperson.assetAccount.assets.Count;
        int d = split / tmpl.Length;
        int r = split % tmpl.Length;
        int st = 0;
        foreach(Person p in tmpl)
        {
            for(int i=0;i< d; i++)
            {
                deadperson.assetAccount.TransferAssetTaxFree(p.assetAccount, p.bankAccounts[0], deadperson.bankAccounts[0], 0, deadperson.assetAccount.assets[st * 1 + i]);
                if (i + 1 == d) {
                    st++;
                }

            }
           
        }
        for (int j =0;j<r;j++)
        {
            deadperson.assetAccount.TransferAssetTaxFree(tmpl[tmpl.Length - j].assetAccount, tmpl[tmpl.Length - j].bankAccounts[0], deadperson.bankAccounts[0],0, deadperson.assetAccount.assets[split - j]);
        }
    }
    public void SplitHeirdomWithTestament(Person deadperson)
    {
        Testament t = deadperson.testament;
        foreach(Person p in t.assetDivide.Keys)
        {
            int stI = 0;
            for(int i = 0; i < p.bankAccounts.Length; i++)
            {
                if (p.bankAccounts[i].accountBlocked) {
                    stI++;
                }
                else
                {
                    break;
                }

            }
            deadperson.assetAccount.TransferAssetTaxFree(p.assetAccount, p.bankAccounts[stI], deadperson.bankAccounts[0], 0, t.assetDivide[p]);
        }
        foreach(Person p in t.moneyDivide.Keys)
        {
            int stI = 0;
            for (int i = 0; i < p.bankAccounts.Length; i++)
            {
                if (p.bankAccounts[i].accountBlocked)
                {
                    stI++;
                }
                else
                {
                    break;
                }

            }
            int stD = 0;
            for (int i = 0; i < deadperson.bankAccounts.Length; i++)
            {
                if (deadperson.bankAccounts[i].accountBlocked)
                {
                    stD++;
                }
                else
                {
                    break;
                }

            }
            if(stD < deadperson.bankAccounts.Length - 1)
            {
                break;
            }
            if (stI < p.bankAccounts.Length - 1)
            {
                deadperson.bankAccounts[stD].TransferMoneyTaxFree(p.bankAccounts[stI], "HS MTRANSFER FROM " + deadperson.ID, (int)t.moneyDivide[p]);
            }
           
        }
    }

}

