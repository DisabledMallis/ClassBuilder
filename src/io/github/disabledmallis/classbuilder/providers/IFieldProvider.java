package io.github.disabledmallis.classbuilder.providers;

public interface IFieldProvider extends ISymbolProvider {
    ITypeProvider getType();
    int getOffset();
}
