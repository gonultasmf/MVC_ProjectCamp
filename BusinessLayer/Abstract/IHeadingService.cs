using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetList();
        List<Heading> GetListByWriter(int id);
        void HeadingAddBL(Heading heading);
        Heading GetByIDBL(int id);
        void HeadingDeleteBL(Heading heading);
        void HeadingUpdateBL(Heading heading);
    }
}
