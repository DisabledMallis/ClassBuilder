package io.github.disabledmallis.classbuilder.builders;

public interface ISourceBuilder {
    /*
    * Appends a new keyword to the source
    * */
    ISourceBuilder keyword(String keyword);
    /*
    * Appends a double-quote enclosed string of text
    * */
    ISourceBuilder string(String text);
    /*
    * Appends the unaltered text to the generated source
    * */
    ISourceBuilder direct(String text);
    /*
    * Pushes a new scope to the source
    * */
    ISourceBuilder pushScope();
    /*
    * Pops the last scope
    * */
    ISourceBuilder popScope();
    /*
    * Pushes a newline
    * */
    ISourceBuilder newline();
    /*
    * Inserts indents to the source
    * */
    ISourceBuilder indent();
    /*
    * Inserts the respective code ending character (; for java and C++ for example)
    * */
    ISourceBuilder endCode();
    /*
    * Get the finished source code as a String
    * */
    String result();
}
