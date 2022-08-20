package io.github.disabledmallis.classbuilder.providers.json;

import com.google.gson.Gson;
import io.github.disabledmallis.classbuilder.providers.IFieldProvider;
import io.github.disabledmallis.classbuilder.providers.IFunctionTypeProvider;
import io.github.disabledmallis.classbuilder.providers.ITypeProvider;
import io.github.disabledmallis.classbuilder.providers.base.BasicSymbolProvider;

import java.util.ArrayList;

public class JsonFunctionTypeProvider extends JsonSymbolProvider implements IFunctionTypeProvider, IJsonProvider {

    public JsonFunctionTypeProvider(Gson jsonObject) {
        super(jsonObject);
    }

    @Override
    public ITypeProvider getReturnType() {
        return getObject().fromJson("return_type", JsonTypeProvider.class);
    }

    @Override
    public ArrayList<IFieldProvider> getParameters() {
        return getObject().fromJson("parameters", ArrayList.class);
    }
}
