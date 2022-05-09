namespace BackRowCommerceApp.Infrastructure
{
    public class Constants
    {
        public enum States
        {
            AL, AK, AZ, AR, CA, CO, CT, DE, FL, GA, HI, ID, IL, IN, IA, KS, KY, LA, ME, MD, MA, MI, MN, MS, MO,
            MT, NE, NV, NH, NJ, NM, NY, NC, ND, OH, OK, OR, PA, RI, SC, SD, TN, TX, UT, VT, VA, WA, WV, WI, WY
        }

        public enum TransactionType
        {
            CR, DR
        }

        public Constants() { }

        public IDictionary<States, string> statesMap()
        {
            IDictionary<States, string> states = new Dictionary<States, string>();
            states.Add(States.AL, "Alabama");
            states.Add(States.AK, "Alaska");
            states.Add(States.AZ, "Arizona");
            states.Add(States.AR, "Arkansas");
            states.Add(States.CA, "California");
            states.Add(States.CO, "Colorado");
            states.Add(States.CT, "Connecticut");
            states.Add(States.DE, "Delaware");
            states.Add(States.FL, "Florida");
            states.Add(States.GA, "Georgia");
            states.Add(States.HI, "Hawaii");
            states.Add(States.ID, "Idaho");
            states.Add(States.IL, "Illinois");
            states.Add(States.IN, "Indiana");
            states.Add(States.IA, "Iowa");
            states.Add(States.KS, "Kansas");
            states.Add(States.KY, "Kentucky");
            states.Add(States.LA, "Louisiana");
            states.Add(States.ME, "Maine");
            states.Add(States.MD, "Maryland");
            states.Add(States.MA, "Massachusetts");
            states.Add(States.MI, "Michigan");
            states.Add(States.MN, "Minnesota");
            states.Add(States.MS, "Mississippi");
            states.Add(States.MO, "Missouri");
            states.Add(States.MT, "Montana");
            states.Add(States.NE, "Nebraska");
            states.Add(States.NV, "Nevada");
            states.Add(States.NH, "New Hampshire");
            states.Add(States.NJ, "New Jersey");
            states.Add(States.NM, "New Mexico");
            states.Add(States.NY, "New York");
            states.Add(States.NC, "North Carolina");
            states.Add(States.ND, "North Dakota");
            states.Add(States.OH, "Ohio");
            states.Add(States.OK, "Oklahoma");
            states.Add(States.OR, "Oregon");
            states.Add(States.PA, "Pennsylvania");
            states.Add(States.RI, "Rhode Island");
            states.Add(States.SC, "South Carolina");
            states.Add(States.SD, "South Dakota");
            states.Add(States.TN, "Tennessee");
            states.Add(States.TX, "Texas");
            states.Add(States.UT, "Utah");
            states.Add(States.VT, "Vermont");
            states.Add(States.VA, "Virginia");
            states.Add(States.WA, "Washington");
            states.Add(States.WV, "West Virginia");
            states.Add(States.WI, "Wisconsin");
            states.Add(States.WY, "Wyoming");

            return states;
        }

        public States? findKey(string state)
        {
            IDictionary<States, string> states = statesMap();

            foreach (KeyValuePair<States, string> kvp in states)
            {
                if (kvp.Value == state)
                {
                    return kvp.Key;
                }
            }

            return null;
        }
    }
}

