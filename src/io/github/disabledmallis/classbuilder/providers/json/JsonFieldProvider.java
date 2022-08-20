package io.github.disabledmallis.classbuilder.providers.json;

import com.google.gson.Gson;
import io.github.disabledmallis.classbuilder.providers.IFieldProvider;
import io.github.disabledmallis.classbuilder.providers.ITypeProvider;

public class JsonFieldProvider extends JsonSymbolProvider implements IFieldProvider, IJsonProvider {
    public JsonFieldProvider(Gson jsonObject) {
        super(jsonObject);
    }

    @Override
    public ITypeProvider getType() {
        return null;
    }

    @Override
    public int getOffset() {
        return getObject().get("offset").getAsInt();
    }
}
