﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePackage.Execution.Operators
{
    /// <summary>
    /// Instruction that represents "^"
    /// </summary>
    public class Xor : BinaryOperator
    {
        /// <summary>
        /// Constructor that 
        /// </summary>
        /// <param name="lOpType">Type of the left operand</param>
        /// <param name="rOpType">Type of the right operand</param>
        /// <param name="resType">Type of the returned value</param>
        public Xor(Entity.DataType lOpType, Entity.DataType rOpType, Entity.DataType resType) :
            base(lOpType, rOpType,
                delegate(Entity.Variable left, Entity.Variable right)
                {
                    return left.Type.OperatorXor(left.Value, right.Value);
                }, resType)
        {

        }
    }
}
