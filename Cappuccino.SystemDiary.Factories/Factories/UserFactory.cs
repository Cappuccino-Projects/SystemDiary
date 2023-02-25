using Cappuccino.SystemDiary.Factories.Abstract;
using Models.Enums;
using Models.Users;

namespace Cappuccino.SystemDiary.Factories.Factories
{
	public sealed class UserFactory : FactoryAbstract
	{
		private List<UserModel> _userModels = new();

		public override void Create()
		{
			_userModels.Add(new ()
			{
				Name = "Алексей",
				Surname = "Волков",
				Fathername = "Викторович",
				Email = "alex.volkovdd@gmail.com",
				Password = "1111",
				Birth = new DateTime(2004, 3, 7),
				Login = "login4",
				Gender = Genders.Male,
			});
		}
	}
}
