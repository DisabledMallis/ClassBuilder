package io.github.disabledmallis.classbuilder.builders;

import java.util.logging.Level;
import java.util.logging.Logger;

public class CppSourceBuilder implements ISourceBuilder {
    private StringBuilder innerBuilder;
    private int scopeCnt = 0;
    private boolean formatted = false;
    private boolean useTabs = true;
    private int indentCnt = 1;

    public CppSourceBuilder() {
        this.innerBuilder = new StringBuilder();
    }

    public CppSourceBuilder(boolean formatted, boolean useTabs, int indentCount) {
        this.innerBuilder = new StringBuilder();
        this.formatted = formatted;
        this.useTabs = useTabs;
        this.indentCnt = indentCount;
    }

    @Override
    public ISourceBuilder keyword(String keyword) {
        this.innerBuilder.append(keyword+" ");
        return this;
    }

    @Override
    public ISourceBuilder string(String text) {
        this.innerBuilder.append("\"");
        this.innerBuilder.append(text);
        this.innerBuilder.append("\"");
        return this;
    }

    @Override
    public ISourceBuilder direct(String text) {
        this.innerBuilder.append(text);
        return this;
    }

    @Override
    public ISourceBuilder pushScope() {
        this.innerBuilder.append("{");
        this.scopeCnt++;
        return this;
    }

    @Override
    public ISourceBuilder popScope() {
        if(this.scopeCnt == 0) {
            Logger log = Logger.getGlobal();
            log.log(Level.SEVERE, "Tried to pop scope, but we are in global scope!");
            return this;
        }
        this.scopeCnt--;
        if(this.formatted)
            this.indent();
        this.innerBuilder.append("}");
        if(this.formatted)
            this.newline();
        return this;
    }

    @Override
    public ISourceBuilder newline() {
        this.innerBuilder.append("\n");
        return this;
    }

    @Override
    public ISourceBuilder indent() {
        if(this.useTabs) {
            for(int i = 0; i < this.indentCnt; i++) {
                this.innerBuilder.append("\t");
            }
        } else {
            for(int i = 0; i < this.indentCnt; i++) {
                this.innerBuilder.append(" ");
            }
        }
        return this;
    }

    @Override
    public ISourceBuilder endCode() {
        this.innerBuilder.append(";");
        return this;
    }

    @Override
    public String result() {
        return this.innerBuilder.toString();
    }
}
