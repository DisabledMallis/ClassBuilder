package io.github.disabledmallis.classbuilder.providers.base;

import io.github.disabledmallis.classbuilder.providers.IStructProvider;
import io.github.disabledmallis.classbuilder.providers.ITypeTree;

import java.util.ArrayList;

public class BasicTypeTree implements ITypeTree {
    private ArrayList<IStructProvider> structs;
    public BasicTypeTree(ArrayList<IStructProvider> structs) {
        this.structs = structs;
    }
    @Override
    public ArrayList<IStructProvider> getStructs() {
        return null;
    }
}
