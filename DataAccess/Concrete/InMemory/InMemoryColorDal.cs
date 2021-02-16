using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryColorDal : IColorDal
    {
        private List<Color> colors = new List<Color>
        {
            new Color {ColorName = "Blue", Id = 1},
            new Color { ColorName="Yellow",Id=2},
            new Color { ColorName="Black",Id=3},
            new Color { ColorName="White",Id=4},
        };
        public List<Color> GetAll()
        {
            return colors;
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Add(Color color)
        {
            colors.Add(color);
        }

        public void Update(Color color)
        {
            var updatedColor = colors.SingleOrDefault(p => p.Id == color.Id);
            updatedColor.ColorName = color.ColorName;
        }

        public void Delete(Color color)
        {
            var deletedColorr = colors.SingleOrDefault(p => p.Id == color.Id);
            colors.Remove(deletedColorr);
        }
    }
}
