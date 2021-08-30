using Delegates;
using UnityEngine;

namespace Controllers
{
    public class DamageController : HealthController
    {
        public event ReturnDamage DamageEvent;
        public event ReturnDamageCharacter DamageCharacterEvent;

        public void AddDamage(float value)
        {
            if (!_isNotDamage) SubHealth(value);
            Debug.Log("DAMAGE");
            //DamageEvent?.Invoke(value, damageType);
        }
        private bool _isNotDamage = false;
        //Will be invoked from another type 
        public void AddDamage(float value, DamageType damageType)
        {
            if (!_isNotDamage) SubHealth(value);
            DamageEvent?.Invoke(value, damageType);
        }
        //Invoked in AttackControllers on SendMassage()
        public void AddDamage(float value, DamageType damageType, Character.Character character)
        {
            Debug.Log("Add Damage");
            if (!_isNotDamage) SubHealth(value);
            DamageCharacterEvent?.Invoke(value, damageType, character);
            Debug.Log(($"character attacked {character.Username}"));
        }
        public void SetDamageState(bool value)
        {
            _isNotDamage = value;
        }
    }

    public enum DamageType
    {
        Character,
        Height
    }
}
