package io.github.disabledmallis.classbuilder.providers.base;

import io.github.disabledmallis.classbuilder.providers.IFieldProvider;
import io.github.disabledmallis.classbuilder.providers.IFunctionProvider;
import io.github.disabledmallis.classbuilder.providers.ITypeProvider;

import java.util.ArrayList;

public class BasicFunctionProvider extends BasicFunctionTypeProvider implements IFunctionProvider {
    public BasicFunctionProvider(ITypeProvider type, ArrayList<IFieldProvider> params, String name) {
        super(type, params, name);
    }
}
