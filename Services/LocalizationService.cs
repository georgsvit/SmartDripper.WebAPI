using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDripper.WebAPI.Services
{
    public class LocalizationService : IStringLocalizer
    {
        private readonly Dictionary<string, Dictionary<string, string>> resources;

        public LocalizationService()
        {
            Dictionary<string, string> enDictionary = GetEnglishLocalization();
            Dictionary<string, string> uaDictionary = GetUkrainianLocalization();

            CheckInitializationCorrectness(enDictionary, uaDictionary);

            resources = new Dictionary<string, Dictionary<string, string>>
            {
                {"en", enDictionary },
                {"ua", uaDictionary }
            };
        }

        private void CheckInitializationCorrectness(Dictionary<string, string> enDictionary, Dictionary<string, string> uaDictionary)
        {
            if (enDictionary.Count != uaDictionary.Count) throw new Exception("Localization service failed. Dictionaries have different number of strings.");

            foreach (var value in enDictionary)
            {
                if (!uaDictionary.ContainsKey(value.Key)) throw new Exception($"Localization service failed. On key {value.Key}.");
            }
        }

        public LocalizedString this[string name]
        {
            get
            {
                var currentCulture = CultureInfo.CurrentCulture.Name;
                if (resources.ContainsKey(currentCulture))
                {
                    if (resources[currentCulture].ContainsKey(name))
                    {
                        return new LocalizedString(name, resources[currentCulture][name]);
                    }
                    else
                    {
                        throw new Exception($"Localization failed. Localization string is not defined: '{name}'.");
                    }
                }
                else
                {
                    throw new Exception($"Localization failed. This culture is not supported: '{currentCulture}'.");
                }
            }
        }

        public LocalizedString this[string name, params object[] arguments] => this[name];

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            var currentCulture = CultureInfo.CurrentCulture.Name;
            return resources[currentCulture].Select((pair) => new LocalizedString(pair.Key, pair.Value));
        }

        public IStringLocalizer WithCulture(CultureInfo culture) => this;


        private Dictionary<string, string> GetEnglishLocalization()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            dictionary.Add("Login failed. The user is not an admin.", "Login failed. The user is not an admin.");
            dictionary.Add("Appointment with this identifier doesn`t exist.", "Appointment with this identifier doesn`t exist.");
            dictionary.Add("Login failed. The user is not an device.", "Login failed. The user is not an device.");
            dictionary.Add("Cannot delete this device.", "Cannot delete this device.");

            dictionary.Add("Device with this identifier doesn`t exist.", "Device with this identifier doesn`t exist.");
            dictionary.Add("The user with such id was not found.", "The user with such id was not found.");
            dictionary.Add("The user with such id is not a smart device.", "The user with such id is not a smart device.");
            dictionary.Add("Disease already exists.", "Disease already exists.");

            dictionary.Add("Disease with this identifier doesn`t exist.", "Disease with this identifier doesn`t exist.");
            dictionary.Add("Login failed. The user is not a nurse.", "Login failed. The user is not a nurse.");
            dictionary.Add("Login failed. The user is not a doctor.", "Login failed. The user is not a doctor.");
            dictionary.Add("The user with such login is already registered.", "The user with such login is already registered.");

            dictionary.Add("The user with such login doesn`t exist.", "The user with such login doesn`t exist.");
            dictionary.Add("The password isn`t correct.", "The password isn`t correct.");
            dictionary.Add("Manufacturer already exists.", "Manufacturer already exists.");
            dictionary.Add("Manufacturer with this identifier doesn`t exist.", "Manufacturer with this identifier doesn`t exist.");

            dictionary.Add("MedicalProtocol already exists.", "MedicalProtocol already exists.");
            dictionary.Add("MedicalProtocol with this identifier doesn`t exist.", "MedicalProtocol with this identifier doesn`t exist.");
            dictionary.Add("Medicament already exists.", "Medicament already exists.");
            dictionary.Add("Medicament with this identifier doesn`t exist.", "Medicament with this identifier doesn`t exist.");

            dictionary.Add("Patient already exists.", "Patient already exists.");
            dictionary.Add("Patient with this identifier doesn`t exist.", "Patient with this identifier doesn`t exist.");
            dictionary.Add("Procedure already exists.", "Procedure already exists.");
            dictionary.Add("Procedure with this identifier doesn`t exist.", "Procedure with this identifier doesn`t exist.");
            //dictionary.Add("", "");
            
            return dictionary;
        }

        private Dictionary<string, string> GetUkrainianLocalization()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            dictionary.Add("Login failed. The user is not an admin.", "Помилка входу. Користувач не є адміністратором.");
            dictionary.Add("Appointment with this identifier doesn`t exist.", "Медичне призначення з таким ідентифікатором не існує.");
            dictionary.Add("Login failed. The user is not an device.", "Помилка входу. Користувач не є смарт-пристроєм.");
            dictionary.Add("Cannot delete this device.", "Неможливо видалити цей смарт-пристрій.");

            dictionary.Add("Device with this identifier doesn`t exist.", "Смарт-пристрій з таким ідентифікатором не існує.");
            dictionary.Add("The user with such id was not found.", "Користувача з таким ідентифікатором не знайдено.");
            dictionary.Add("The user with such id is not a smart device.", "Користувач з таким ідентифікатором не є смарт-пристроєм.");
            dictionary.Add("Disease already exists.", "Ця хвороба вже існує.");

            dictionary.Add("Disease with this identifier doesn`t exist.", "Хвороба з таким ідентифікатором не існує.");
            dictionary.Add("Login failed. The user is not a nurse.", "Помилка входу. Користувач не є медсемтрою.");
            dictionary.Add("Login failed. The user is not a doctor.", "Помилка входу. Користувач не є доктором.");
            dictionary.Add("The user with such login is already registered.", "Користувач з таким логіном вже існує.");

            dictionary.Add("The user with such login doesn`t exist.", "Користувач з таким логіном не існує.");
            dictionary.Add("The password isn`t correct.", "Невірний пароль.");
            dictionary.Add("Manufacturer already exists.", "Такий виробник вже існує.");
            dictionary.Add("Manufacturer with this identifier doesn`t exist.", "Виробник з таким ідентифікатором не існує.");

            dictionary.Add("MedicalProtocol already exists.", "Такий медичний протокол вже існує.");
            dictionary.Add("MedicalProtocol with this identifier doesn`t exist.", "Медичний протокол з таким ідентифікатором не існує.");
            dictionary.Add("Medicament already exists.", "Такий препарат вже існує.");
            dictionary.Add("Medicament with this identifier doesn`t exist.", "Препарат з таким ідентифікатором не існує.");

            dictionary.Add("Patient already exists.", "Такий пацієнт вже існує.");
            dictionary.Add("Patient with this identifier doesn`t exist.", "Пацієнт з таким ідентифікатором не існує.");
            dictionary.Add("Procedure already exists.", "Така процедура вже існує.");
            dictionary.Add("Procedure with this identifier doesn`t exist.", "Процедура з таким ідентифікатором не існує.");
            //dictionary.Add("", "");
            
            return dictionary;
        }
    }
}
