package io.github.disabledmallis.classbuilder.providers.base;

import io.github.disabledmallis.classbuilder.providers.IFieldProvider;
import io.github.disabledmallis.classbuilder.providers.IFunctionProvider;
import io.github.disabledmallis.classbuilder.providers.IStructProvider;
import io.github.disabledmallis.classbuilder.providers.IVirtualFunctionProvider;

import java.util.ArrayList;

public class BasicStructProvider extends BasicSymbolProvider implements IStructProvider {
    private ArrayList<IFieldProvider> fields;
    private ArrayList<IFunctionProvider> functions;
    private ArrayList<IVirtualFunctionProvider> virtuals;

    public BasicStructProvider(String name,
                               ArrayList<IFieldProvider> fields,
                               ArrayList<IFunctionProvider> functions,
                               ArrayList<IVirtualFunctionProvider> virtuals) {
        super(name);
        this.fields = fields;
        this.functions = functions;
        this.virtuals = virtuals;
    }

    @Override
    public ArrayList<IFieldProvider> getFields() {
        return fields;
    }

    @Override
    public ArrayList<IFunctionProvider> getFunctions() {
        return functions;
    }

    @Override
    public ArrayList<IVirtualFunctionProvider> getVirtuals() {
        return virtuals;
    }
}
