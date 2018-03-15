Requirement that executes an expression to check whether the requirement is met.  Can access data in the [[persistent data store|Extending#using-the-persistent-data-store]].

<pre>
REQUIREMENT
{
    name = Expression
    type = Expression

    // Title to use for the requirement when displaying it in Mission Control.
    // This is generally required for expression requirements, as there is no
    // logical default that can be generated.  Can be ignored if the requirement
    // is a child of a PARAMETER or is otherwise hidden.
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  Conditional
    //
    title = Need astronauts with gumption

    // The expression to be executed is in the expression field.  It supports
    // arithmetic operators (+, -, *, /), boolean operators (&&, ||, !),
    // comparisons (<, <=, ==, !=, >=, >) and parenthesis.  It is able to
    // access data in the persistent data store.
    //
    // Type:      <a href="String-Type">string</a>
    // Required:  Yes
    //
    expression = CC_EXPTEST_Success == 1 || !CC_TestVal
}
</pre>
