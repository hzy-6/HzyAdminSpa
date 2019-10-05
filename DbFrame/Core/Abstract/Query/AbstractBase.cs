using System;
using System.Collections.Generic;
using System.Text;

namespace DbFrame.Core.Abstract.Query
{
    //
    using DbFrame.BaseClass;
    using DbFrame.Core.Abstract;
    using DbFrame.Core.CodeAnalysis;

    //
    public abstract class AbstractBase
    {
        protected SQL SqlCode { get; set; }

        protected AbstractAdo Ado { get; set; }

        protected Analysis analysis { get; set; }

    }
}
