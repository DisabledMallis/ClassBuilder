package io.github.disabledmallis.classbuilder.generators;

import com.google.gson.Gson;
import io.github.disabledmallis.classbuilder.providers.*;

import java.util.ArrayList;

public interface ISourceGenerator {
    ArrayList<String> generate(ITypeTree structTree);
    String generateStruct(IStructProvider theStruct);
    String generateField(IFieldProvider theField);
    String generateFunction(IFunctionProvider theFunc);
    String generateVirtual(IVirtualFunctionProvider theVirt);
}
