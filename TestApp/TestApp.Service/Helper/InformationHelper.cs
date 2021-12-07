using TestApp.Shared.Models;

namespace TestApp.Service.Helper
{
    public class InformationHelper
    {
        public static List<Information> _informations;
        static InformationHelper()
        {
            _informations = new List<Information>();
            _informations.Add(new Information() { Id = 0, Header = "Test 1", Description = "This is test description" });
            _informations.Add(new Information() { Id = 1, Header = "Test 2", Description = "This is test description" });
            _informations.Add(new Information() { Id = 2, Header = "Test 3", Description = "This is test description" });
            _informations.Add(new Information() { Id = 3, Header = "Test 4", Description = "This is test description" });
            _informations.Add(new Information() { Id = 4, Header = "Test 5", Description = "This is test description" });
            _informations.Add(new Information() { Id = 5, Header = "Test 6", Description = "This is test description" });
            _informations.Add(new Information() { Id = 6, Header = "Test 7", Description = "This is test description" });
            _informations.Add(new Information() { Id = 7, Header = "Test 8", Description = "This is test description" });
            _informations.Add(new Information() { Id = 8, Header = "Test 9", Description = "This is test description" });
            _informations.Add(new Information() { Id = 9, Header = "Test 10", Description = "This is test description" });
            _informations.Add(new Information() { Id = 10, Header = "Test 11", Description = "This is test description" });
            _informations.Add(new Information() { Id = 11, Header = "Test 12", Description = "This is test description" });
        }

        public IEnumerable<Information> GetAllInformations()
        {
            return _informations;
        }

        public Information GetAllInformation(int id)
        {
            if (_informations.Any(x => x.Id == id))
            {
                return _informations.FirstOrDefault(x => x.Id == id);
            }
            else
                return null;
        }

        public Information AddInformation(Information information)
        {
            _informations.Add(information);
            return information;
        }
        public Information UpdateInformation(int id, Information information)
        {
            if (_informations.Any(x => x.Id == id))
            {
                Information info = _informations.FirstOrDefault(x => x.Id == id);
                if (info != null)
                {
                    info.Header = information.Header;
                    info.Description = information.Description;

                    return information;
                }
                else
                    return null;
            }
            else
            {
                return null;
            }
        }

        public bool DeleteInformation(int id)
        {
            if (_informations.Any(x => x.Id == id))
            {
                bool v = _informations.Remove(_informations.FirstOrDefault(x => x.Id == id));
                return v;
            }
            else
            {
                return false;
            }
        }
    }
}
