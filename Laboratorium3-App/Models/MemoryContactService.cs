﻿using Data.Entities;

namespace Laboratorium3_App.Models
{
    public class MemoryContactService : IContactService
    {
        private Dictionary<int, Contact> _items = new Dictionary<int, Contact>();
        private IDateTimeProvider _timeProvider;

        public MemoryContactService(IDateTimeProvider timeProvider)
        {
            _timeProvider = timeProvider;
        }
        public int Add(Contact item)
        {
            int id = _items.Keys.Count != 0 ? _items.Keys.Max() : 0;
            item.Created = _timeProvider.Actual();
            item.Id = id + 1;
            _items.Add(item.Id, item);
            return item.Id;
        }

        public void Delete(int id)
        {
            _items.Remove(id);
        }

        public List<Contact> FindAll()
        {
            return _items.Values.ToList();
        }

        public List<OrganizationEntity> FindAllOrganizations()
        {
            throw new NotImplementedException();
        }

        public Contact? FindById(int id)
        {
            if (_items.ContainsKey(id))
            {
                return _items[id];
            }
            else
            {
                return null;
            }
        }


        public PagingList<Contact> FindPage(int page, int size)
        {
            throw new NotImplementedException();
        }

        public void Update(Contact item)
        {
            
            _items[item.Id] = item;
        }
    }
}
