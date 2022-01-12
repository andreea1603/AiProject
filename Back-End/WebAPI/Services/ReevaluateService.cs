using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Entities;
using WebAPI.Helpers;

namespace WebAPI.Services
{
    public interface IReevalService
    {
        List<Reeval> GetFirstX(int x);
        Reeval Create(Reeval reeval);
        void Delete(int id);
    }

    public class ReevalService : IReevalService
    {
        private readonly DataContext _context;

        public ReevalService(DataContext context)
        {
            _context = context;
        }

  
        public List<Reeval> GetFirstX(int x)
        {
            List<Reeval> reevaluation= new List<Reeval>();
            var reevaluations = _context.Reevaluation;
            int i = 0;
            foreach (var reeval in reevaluations)
            {
                reevaluation.Add(reeval);
                i = i + 1;
                if(i == x)
                {
                    return reevaluation;

                }

            }
            return reevaluation;

            //_context.Reevaluation.Where(p => p.Id == 1);
        }


        public Reeval Create(Reeval reeval)
        {
            // validation
            if (string.IsNullOrWhiteSpace(reeval.Tweet))
                throw new AppException("tweet is required");

            if (_context.Reevaluation.Any(x => x.Tweet == reeval.Tweet))
                throw new AppException("Username \"" +  "\" is already taken");
            Console.WriteLine(reeval.Id + reeval.Tweet);

            _context.Reevaluation.Add(reeval);
            _context.SaveChanges();

            return reeval;
        }



        public void Delete(int id)
        {
            Console.WriteLine("NNUNUNUNUu imi place aici");

            var reeval = _context.Reevaluation.Find(id);
            Console.WriteLine("IMI place aici");

            if (reeval != null)
            {
                _context.Reevaluation.Remove(reeval);
                _context.SaveChanges();
                Console.WriteLine("Asa si asa");

            }
            Console.WriteLine("Nu imi place aici");

        }

    }
}
