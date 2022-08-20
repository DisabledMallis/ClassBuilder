package io.github.disabledmallis.classbuilder.providers.json;

import com.google.gson.Gson;
import io.github.disabledmallis.classbuilder.providers.IVirtualFunctionProvider;

public class JsonVirtualFunctionProvider extends JsonFunctionTypeProvider implements IVirtualFunctionProvider, IJsonProvider {
    public JsonVirtualFunctionProvider(Gson jsonObject) {
        super(jsonObject);
    }
}
