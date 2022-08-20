package io.github.disabledmallis.classbuilder.providers.base;

import io.github.disabledmallis.classbuilder.providers.ITypeProvider;

public class BasicTypeProvider extends BasicSymbolProvider implements ITypeProvider {
    private int size;

    public BasicTypeProvider(String name, int size) {
        super(name);
        this.size = size;
    }

    @Override
    public int getSize() {
        return size;
    }
}
