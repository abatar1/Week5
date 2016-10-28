using System;

namespace Week5
{
    public class Processor<T, TRequest>
    {
        public Processor(Func<TRequest, bool> check, Func<TRequest, T> register, Action<T> save)
        {
            Check = check;
            Register = register;
            Save = save;
        }

        public T Process(TRequest request)
        {
            if (!Check(request))
                throw new ArgumentException();
            var result = Register(request);
            Save(result);
            return result;
        }

        private Func<TRequest, bool> Check;
        private Func<TRequest, T> Register;
        private Action<T> Save;
    }
}
