using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> GetList();
        void ContactAddBL(Contact contact);
        Contact GetByIDBL(int id);
        void ContactDeleteBL(Contact contact);
        void ContactUpdateBL(Contact contact);
    }
}
