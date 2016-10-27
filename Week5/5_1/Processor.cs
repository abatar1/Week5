using System;

namespace Week5
{
    public class Processor<T, TRequest>
    {
        public T Process(TRequest request)
        {
            if (!Check(request))
                throw new ArgumentException();
            var result = Register(request);
            Save(result);
            return result;
        }

        public Func<TRequest, bool> Check;
        public Func<TRequest, T> Register;
        public Action<T> Save;
    }
}
