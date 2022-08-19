package io.github.disabledmallis.classbuilder.providers;

import java.util.ArrayList;

public interface IFunctionTypeProvider extends ISymbolProvider {
    ITypeProvider getReturnType();
    ArrayList<IFieldProvider> getParameters();
}
