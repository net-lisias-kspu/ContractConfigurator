Requirement that executes an expression to check whether the requirement is met.  Can access data in the persistent data store.

    REQUIREMENT
    {
        name = Expression
        type = Expression

        // The expression to be executed is in the expression field.  It supports
        // arithmetic operators (+, -, *, /), boolean operators (&&, ||, !),
        // comparisons (<, <=, ==, !=, >=, >) and parenthesis.  It is able to
        // access data in the persistent data store.
        expression = CC_EXPTEST_Success == 1 || !CC_TestVal
    }
