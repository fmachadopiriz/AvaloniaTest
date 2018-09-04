namespace AvaloniaTest.Models
{
    using System.Collections;
    using System.Collections.Generic;

    public class Phrase : IEnumerable
    {
        private IList<Word> terms;

        public Phrase()
        {
            terms = new List<Word>();
        }

        Word this[int index]
        {
            get
            {
                return terms[index];
            }
        }

        public void AddTerm(Word term)
        {
            terms.Add(term);
        }

        public IEnumerator GetEnumerator()
        {
            //return ((IEnumerable)terms).GetEnumerator();
            return terms.GetEnumerator();
        }

        public void RemoveTerm(Word term)
        {
            terms.Remove(term);
        }
    }
}