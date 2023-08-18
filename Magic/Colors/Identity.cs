namespace Colors
{
    public class Identity
    {
        public string Name { get; set; }
        public List<Color> Colors { get; set; }
        
        public Identity(string name, params Color[] colors)
        {
            this.Name = name;
            this.Colors = new();

            foreach (Color color in colors) {
                this.Colors.Add(color);
            }
        }
        
        public static List<Identity> CreateIdentities()
        {
            List<Identity> allIdentities = new();
            
            Color black = new Color("Black");
            Color blue = new Color("Blue");
            Color green = new Color("Green");
            Color red = new Color("Red");
            Color white = new Color("White");
            
            Identity monoBlack = new Identity("Black", black);
            Identity monoBlue = new Identity("Blue", blue);
            Identity monoGreen = new Identity("Green", green);
            Identity monoRed = new Identity("Red", red);
            Identity monoWhite = new Identity("White", white);

            allIdentities.Add(monoBlack);
            allIdentities.Add(monoBlue);
            allIdentities.Add(monoGreen);
            allIdentities.Add(monoRed);
            allIdentities.Add(monoWhite);

            Identity azorius = new Identity("Azorius", white, blue);
            Identity boros = new Identity("Boros", red, white);
            Identity dimir = new Identity("Dimir", blue, black);
            Identity golgari = new Identity("Golgari", black, green);
            Identity gruul = new Identity("Gruul", red, green);
            Identity izzet = new Identity("Izzet", blue, red);
            Identity orzhov = new Identity("Orzhov", white, black);
            Identity rakdos = new Identity("Rakdos", black, red);
            Identity selesnya = new Identity("Selesnya", white, green);
            Identity simic = new Identity("Simic", blue, green);

            allIdentities.Add(azorius);
            allIdentities.Add(boros);
            allIdentities.Add(dimir);
            allIdentities.Add(golgari);
            allIdentities.Add(gruul);
            allIdentities.Add(izzet);
            allIdentities.Add(orzhov);
            allIdentities.Add(rakdos);
            allIdentities.Add(selesnya);
            allIdentities.Add(simic);

            Identity abzan = new Identity("Abzan", white, black, green);
            Identity bant = new Identity("Bant", white, blue, green);
            Identity esper = new Identity("Esper", white, blue, black);
            Identity grixis = new Identity("Grixis", blue, black, red);
            Identity jeskai = new Identity("Jeskai", white, blue, red);
            Identity jund = new Identity("Jund", black, red, green);
            Identity mardu = new Identity("Mardu", white, black, red);
            Identity naya = new Identity("Naya", white, red, green);
            Identity sultai = new Identity("Sultai", blue, black, green);
            Identity temur = new Identity("Temur", blue, red, green);

            allIdentities.Add(abzan);
            allIdentities.Add(bant);
            allIdentities.Add(esper);
            allIdentities.Add(grixis);
            allIdentities.Add(jeskai);
            allIdentities.Add(jund);
            allIdentities.Add(mardu);
            allIdentities.Add(naya);
            allIdentities.Add(sultai);
            allIdentities.Add(temur);

            Identity glint = new Identity("Glint", blue, black, red, green);
            Identity dune = new Identity("Dune", white, black, red, green);
            Identity inkTreader = new Identity("Ink-Treader", white, blue, red, green);
            Identity witch = new Identity("Witch", white, black, blue, green);
            Identity yore = new Identity("Yore", white, black, blue, red);

            allIdentities.Add(glint);
            allIdentities.Add(dune);
            allIdentities.Add(inkTreader);
            allIdentities.Add(witch);
            allIdentities.Add(yore);

            Identity fiveColor = new Identity("Five Color", black, blue, green, red, white);

            allIdentities.Add(fiveColor);

            return allIdentities;
        }
    }
}