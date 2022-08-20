package io.github.disabledmallis.classbuilder.providers.base;

import io.github.disabledmallis.classbuilder.providers.IFieldProvider;
import io.github.disabledmallis.classbuilder.providers.ITypeProvider;

public class BasicFieldProvider extends BasicSymbolProvider implements IFieldProvider {
    private ITypeProvider type;
    private int offset;

    public BasicFieldProvider(String name, ITypeProvider type) {
        super(name);
        this.type = type;
        this.offset = offset;
    }

    @Override
    public ITypeProvider getType() {
        return type;
    }

    @Override
    public int getOffset() {
        return offset;
    }
}
