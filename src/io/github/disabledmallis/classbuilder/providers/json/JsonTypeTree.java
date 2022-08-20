package io.github.disabledmallis.classbuilder.providers.json;

import com.google.gson.Gson;
import io.github.disabledmallis.classbuilder.providers.IStructProvider;
import io.github.disabledmallis.classbuilder.providers.ITypeTree;

import java.util.ArrayList;

public class JsonTypeTree implements ITypeTree, IJsonProvider {
    private Gson jsonObject;
    public JsonTypeTree(Gson jsonObject) {
        this.jsonObject = jsonObject;
    }
    @Override
    public ArrayList<IStructProvider> getStructs() {
        return getObject().fromJson("structs", ArrayList.class);
    }

    @Override
    public Gson getObject() {
        return this.jsonObject;
    }
}
