package io.github.disabledmallis.classbuilder.providers.json;

import com.google.gson.Gson;
import io.github.disabledmallis.classbuilder.providers.IFunctionTypeProvider;

public class JsonFunctionProvider extends JsonFunctionTypeProvider implements IFunctionTypeProvider {
    public JsonFunctionProvider(Gson jsonObject) {
        super(jsonObject);
    }
}
