package io.github.disabledmallis.classbuilder.providers;

import java.util.ArrayList;

public interface IStructProvider extends ISymbolProvider {
    ArrayList<IFieldProvider> getFields();
    ArrayList<IFunctionProvider> getFunctions();
    ArrayList<IVirtualFunctionProvider> getVirtuals();
}