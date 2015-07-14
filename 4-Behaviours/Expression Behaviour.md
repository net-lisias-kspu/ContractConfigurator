Behaviour for executing one or more expressions and storing the results in the persistent data store.

<pre>
BEHAVIOUR
{
    name = Expression
    type = Expression

    // The CONTRACT_ACCEPTED node gets executed when the contract is
    // accepted.
    CONTRACT_ACCEPTED
    {
        // Expressions can use arithmatic operators (+, -, *, /)
        // and parenthesis.
        CC_TestVal = 10 * 2 - 3 * 4
    }

    // The CONTRACT_COMPLETED_SUCCESS node gets executed when the
    // contract is completed successfully.
    CONTRACT_COMPLETED_SUCCESS
    {
        // Multiple expressions may be supplied in one node
        CC_TestVal = CC_TestVal * 2
        CC_EXPTEST_Success = 1
    }

    // The CONTRACT_COMPLETED_FAILURE node gets executed when the
    // contract fails, is withdrawn or the deadline expires.
    CONTRACT_COMPLETED_FAILURE
    {
        CC_TestVal = CC_TestVal / 2
        CC_EXPTEST_Success = 0
    }

    // The PARAMETER_COMPLETED node gets executed when a parameter
    // is successfully completed.
    PARAMETER_COMPLETED
    {
        // Supply the name of the parameter
        parameter = SomeParameter

        CC_TestVal = 100
    }
}
</pre>
