package io.github.disabledmallis.classbuilder.providers.base;

import io.github.disabledmallis.classbuilder.providers.IFieldProvider;
import io.github.disabledmallis.classbuilder.providers.IFunctionTypeProvider;
import io.github.disabledmallis.classbuilder.providers.ITypeProvider;

import java.util.ArrayList;

public class BasicFunctionTypeProvider extends BasicSymbolProvider implements IFunctionTypeProvider {
    private ITypeProvider type;
    private ArrayList<IFieldProvider> params;

    public BasicFunctionTypeProvider(String name, ITypeProvider type, ArrayList<IFieldProvider> params) {
        super(name);
        this.type = type;
        this.params = params;
    }
    @Override
    public ITypeProvider getReturnType() {
        return type;
    }

    @Override
    public ArrayList<IFieldProvider> getParameters() {
        return params;
    }
}
