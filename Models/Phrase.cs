namespace AvaloniaTest.Models
{
    using System.Collections;
    using System.Collections.Generic;

    public class Phrase : IEnumerable
    {
        private IList<Term> terms;

        public Phrase()
        {
            terms = new List<Term>();
        }

        Term this[int index]
        {
            get
            {
                return terms[index];
            }
        }

        public void AddTerm(Term term)
        {
            terms.Add(term);
        }

        public IEnumerator GetEnumerator()
        {
            //return ((IEnumerable)terms).GetEnumerator();
            return terms.GetEnumerator();
        }

        public void RemoveTerm(Term term)
        {
            terms.Remove(term);
        }
    }
}