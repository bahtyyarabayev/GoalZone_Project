namespace GoalZonePremierLig.Web.Api.Dtos.TeamsDto
{
    public class GetByIdTeamDto
    {
        public int TeamId { get; set; }             

        public string Name { get; set; }           

        public string ShortName { get; set; }     

        public string LogoUrl { get; set; }        

        public string City { get; set; }          

        public string Stadium { get; set; }     

        public bool IsActive { get; set; }
    }
}
