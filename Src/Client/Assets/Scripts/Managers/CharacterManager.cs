﻿using Entities;
using SkillBridge.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

namespace Managers
{
    class CharacterManager : Singleton<CharacterManager>, IDisposable
    {
        public Dictionary<int, Character> Characters = new Dictionary<int, Character>();

        public UnityAction<Character> OnCharacterEnter;
        public UnityAction<Character> OnCharacterLeave;

        public CharacterManager()
        {

        }
        public void Dispose()
        {
            
        }

        public void Init()
        {

        }

        public void Clear()
        {
            int[] keys = this.Characters.Keys.ToArray();
            foreach(var key in keys)
            {
                this.RemoveCharacter(key);
            }
            this.Characters.Clear();
        }

        public void AddCharacters(SkillBridge.Message.NCharacterInfo cha)
        {
            Debug.LogFormat("AddCharacters:{0}:{1}  Map:{2} Entiyt:{3}", cha.Id, cha.Name, cha.mapId, cha.Entity.String());
            Character character = new Character(cha);
            this.Characters[cha.Entity.Id] = character;
            EntityManager.Instance.AddEntity(character);
            if (OnCharacterEnter != null)
            {
                OnCharacterEnter(character);
            }
        }

        public void RemoveCharacter(int characterId)
        {
            Debug.LogFormat("RemoveCharacter :{0}", characterId);
            if(this.Characters.ContainsKey(characterId))
            {
                EntityManager.Instance.RemoveEntity(this.Characters[characterId].Info.Entity);
                if(OnCharacterLeave != null)
                {
                    OnCharacterLeave(this.Characters[characterId]);
                }
                this.Characters.Remove(characterId);
            }
        }
    }
}
