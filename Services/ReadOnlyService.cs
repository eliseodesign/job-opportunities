namespace job_opportunities_asp_react
{
    public class ReadOnlyService : IReadOnlyService
    {
        private readonly IReadOnlyRepository repo;

        public ReadOnlyService(IReadOnlyRepository _repo)
        {
            repo = _repo;
        }

        public async Task<ReadInfoDTO> getAllReadInfo()
        {
            var countriesTask = await repo.getCountries();
            var educationDegreesTask = await repo.getEduDegrees();
            var educationLevelsTask = await repo.getEduLevels();
            var educationSubjectsTask = await repo.getEduSubjects();
            var fieldSectorsTask = await repo.getSectors();
            var gendersTask = await repo.getGenders();
            var maritalStatusesTask = await repo.getMaritalStatus();


            var result = new ReadInfoDTO()
            {
                Countries = countriesTask,
                EducationDegrees = educationDegreesTask,
                EducationLevels = educationLevelsTask,
                EducationSubjects = educationSubjectsTask,
                FieldSectors = fieldSectorsTask,
                Genders = gendersTask,
                MaritalStatuses =  maritalStatusesTask
            };

            return result;
        }
    }
}
