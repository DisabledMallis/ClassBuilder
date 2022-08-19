package io.github.disabledmallis.classbuilder.generators;

import com.google.gson.Gson;
import io.github.disabledmallis.classbuilder.builders.CppSourceBuilder;
import io.github.disabledmallis.classbuilder.providers.*;

import java.util.ArrayList;

public class CPlusPlusGenerator implements ISourceGenerator {
    @Override
    public ArrayList<String> generate(ITypeTree structTree) {
        ArrayList<IStructProvider> structs = structTree.getStructs();
        ArrayList<String> results = new ArrayList<>();
        for(IStructProvider struct : structs) {
            results.add(this.generateStruct(struct));
        }
        return results;
    }

    @Override
    public String generateStruct(IStructProvider theStruct) {
        CppSourceBuilder sourceGen = new CppSourceBuilder();
        sourceGen.keyword("struct");
        sourceGen.name(theStruct.getName());
        sourceGen.pushScope();
        for(IFieldProvider field : theStruct.getFields()) {
            sourceGen.newline();
            sourceGen.direct(generateField(field));
        }
        for(IFunctionProvider func : theStruct.getFunctions()) {
            sourceGen.newline();
            sourceGen.direct(generateFunction(func));
        }
        for(IVirtualFunctionProvider virt : theStruct.getVirtuals()) {
            sourceGen.newline();
            sourceGen.direct(generateVirtual(virt));
        }
        sourceGen.popScope();
        return sourceGen.result();
    }

    @Override
    public String generateField(IFieldProvider theField) {
        CppSourceBuilder sourceGen = new CppSourceBuilder();
        ITypeProvider fieldType = theField.getType();
        sourceGen.indent();
        sourceGen.keyword(fieldType.getName());
        sourceGen.direct(theField.getName());
        sourceGen.endCode();
        return sourceGen.result();
    }

    @Override
    public String generateFunction(IFunctionProvider theFunc) {
        return "";
    }

    @Override
    public String generateVirtual(IVirtualFunctionProvider theVirt) {
        CppSourceBuilder sourceGen = new CppSourceBuilder();
        ITypeProvider returnType = theVirt.getReturnType();
        ArrayList<IFieldProvider> parameters = theVirt.getParameters();
        sourceGen.keyword(returnType.getName());
        sourceGen.direct(theVirt.getName());
        sourceGen.direct("(");
        for(int i = 0; i < parameters.size(); i++) {
            IFieldProvider param = parameters.get(i);
            sourceGen.keyword(param.getType().getName());
            sourceGen.direct(param.getName());
            //Check if this is the last parameter, and if so don't add a comma
            if(i != parameters.size()-1) {
                sourceGen.direct(", ");
            }
        }
        sourceGen.direct(")");
        sourceGen.endCode();
        return sourceGen.result();
    }
}
