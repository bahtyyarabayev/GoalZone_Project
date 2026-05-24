namespace GoalZonePremierLig.Web.Api.Entities
{
    public class Statistics
    {
            public int Id { get; set; }
            public int FixtureId { get; set; }
            public Fixture Fixture { get; set; }

            public int TeamId { get; set; }
            public Team Team { get; set; }

            
            public double BallPossession { get; set; }   
            public int Shots { get; set; }               
            public int ShotsOnTarget { get; set; }       
            public int Passes { get; set; }              
            public int AccuratePasses { get; set; }     
            public int Corners { get; set; }             
            public int Fouls { get; set; }               
            public int Offsides { get; set; }           
        
    }
}
