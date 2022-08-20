package io.github.disabledmallis.classbuilder.providers.json;

import com.google.gson.Gson;
import com.google.gson.JsonObject;
import io.github.disabledmallis.classbuilder.providers.ISymbolProvider;

public class JsonSymbolProvider implements ISymbolProvider, IJsonProvider {
    JsonObject jsonObject;
    public JsonSymbolProvider(JsonObject jsonObject) {
        this.jsonObject = jsonObject;
    }
    @Override
    public String getName() {
        return getObject().fromJson("name", String.class);
    }

    @Override
    public JsonObject getObject() {
        return jsonObject;
    }
}
