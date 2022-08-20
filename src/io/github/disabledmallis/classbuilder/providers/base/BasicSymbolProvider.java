package io.github.disabledmallis.classbuilder.providers.base;

import io.github.disabledmallis.classbuilder.providers.ISymbolProvider;

public class BasicSymbolProvider implements ISymbolProvider {
    private String name;
    public BasicSymbolProvider(String name) {
        this.name = name;
    }
    @Override
    public String getName() {
        return name;
    }
}
