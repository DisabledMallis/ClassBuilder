package io.github.disabledmallis.classbuilder.providers.json;

import com.google.gson.Gson;
import io.github.disabledmallis.classbuilder.providers.IFieldProvider;
import io.github.disabledmallis.classbuilder.providers.IFunctionProvider;
import io.github.disabledmallis.classbuilder.providers.IStructProvider;
import io.github.disabledmallis.classbuilder.providers.IVirtualFunctionProvider;

import java.util.ArrayList;

public class JsonStructProvider extends JsonSymbolProvider implements IStructProvider, IJsonProvider {
    public JsonStructProvider(Gson jsonObject) {
        super(jsonObject);
    }

    @Override
    public ArrayList<IFieldProvider> getFields() {
        return getObject().fromJson("fields", ArrayList.class);
    }

    @Override
    public ArrayList<IFunctionProvider> getFunctions() {
        return getObject().fromJson("functions", ArrayList.class);
    }

    @Override
    public ArrayList<IVirtualFunctionProvider> getVirtuals() {
        return getObject().fromJson("virtuals", ArrayList.class);
    }
}
