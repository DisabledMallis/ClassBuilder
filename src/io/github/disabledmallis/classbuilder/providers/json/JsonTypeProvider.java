package io.github.disabledmallis.classbuilder.providers.json;

import com.google.gson.Gson;
import io.github.disabledmallis.classbuilder.providers.ITypeProvider;

public class JsonTypeProvider extends JsonSymbolProvider implements ITypeProvider {
    public JsonTypeProvider(Gson jsonObject) {
        super(jsonObject);
    }

    @Override
    public int getSize() {
        return getObject().fromJson("size", int.class);
    }
}
