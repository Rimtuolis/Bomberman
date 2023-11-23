using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public class Context
    {
        public string Input { get; set; }
    }

    public class Interpreter
    {
        private readonly IExpression expression;

        public Interpreter(IExpression expression)
        {
            this.expression = expression;
        }

        public bool Interpret(Context context)
        {
            return expression.Interpret(context.Input);
        }
    }
}
