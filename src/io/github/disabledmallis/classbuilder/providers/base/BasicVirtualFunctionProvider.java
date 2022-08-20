package io.github.disabledmallis.classbuilder.providers.base;

import io.github.disabledmallis.classbuilder.providers.IFieldProvider;
import io.github.disabledmallis.classbuilder.providers.ITypeProvider;
import io.github.disabledmallis.classbuilder.providers.IVirtualFunctionProvider;

import java.util.ArrayList;

public class BasicVirtualFunctionProvider extends BasicFunctionTypeProvider implements IVirtualFunctionProvider {
    public BasicVirtualFunctionProvider(String name, ITypeProvider type, ArrayList<IFieldProvider> params) {
        super(name, type, params);
    }
}
