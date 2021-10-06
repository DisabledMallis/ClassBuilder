//Ghidra DumpClass dumps the features of a class from Ghidra for use with ClassBuilder
//@author DisabledMallis
//@category ClassBuilder
//@keybinding 
//@menupath 
//@toolbar 
import java.util.Iterator;
import java.util.Vector;

import javax.swing.*;

import java.awt.*;
import java.awt.event.*;
import java.lang.annotation.Native;

import com.google.gson.Gson;

import ghidra.app.script.GhidraScript;
import ghidra.program.model.mem.*;
import ghidra.program.model.lang.*;
import ghidra.program.model.pcode.*;
import ghidra.program.model.util.*;
import ghidra.program.model.reloc.*;
import ghidra.program.model.data.*;
import ghidra.program.model.block.*;
import ghidra.program.model.symbol.*;
import ghidra.program.model.scalar.*;
import ghidra.program.model.listing.*;
import ghidra.program.model.address.*;

public class DumpClass extends GhidraScript {

	private Gson gson = new Gson();
    public void run() throws Exception {
		selectClassUI();
    }

	public void classFeatureUI(GhidraClass gClass) {
		JFrame frame = new JFrame("ClassBuilder - " + gClass.getName());
		frame.setSize(800,400);
		frame.setVisible(true);

		JPanel contentPanel = new JPanel();
		contentPanel.setLayout(new BorderLayout());

		JPanel optionsPanel = new JPanel();
		optionsPanel.setLayout(new BoxLayout(optionsPanel, BoxLayout.Y_AXIS));

		JCheckBox fieldsBox = new JCheckBox("Fields");
		JCheckBox vFuncsBox = new JCheckBox("VTable");
		JCheckBox funcBox = new JCheckBox("Functions");

		optionsPanel.add(fieldsBox);
		optionsPanel.add(vFuncsBox);
		optionsPanel.add(funcBox);

		contentPanel.add(optionsPanel, BorderLayout.WEST);

		JTextArea generatedJson = new JTextArea();

		NativeClass toGen = new Builder()
							.setName(gClass.getName())
							.build();
		String json = gson.toJson(toGen);
		generatedJson.setText(json);

		contentPanel.add(generatedJson, BorderLayout.CENTER);

		frame.add(contentPanel);
	}

	public void selectClassUI() {
		Program prog = this.getCurrentProgram();
		SymbolTable table = prog.getSymbolTable();
		Iterator<GhidraClass> classNamespaces = table.getClassNamespaces();

		JFrame frame = new JFrame("Select class");
		frame.setSize(800,800);

		Vector<GhidraClass> classVec = new Vector();

		classNamespaces.forEachRemaining(e->{
			classVec.add(e);
		});

		JPanel contentPanel = new JPanel();

		contentPanel.setLayout(new BorderLayout());

		JScrollPane scrollPane = new JScrollPane();
		JList<GhidraClass> classList = new JList(classVec);
		classList.addMouseListener(new MouseAdapter() {
			public void mouseClicked(MouseEvent evt) {
				JList list = (JList)evt.getSource();
				if (evt.getClickCount() == 2) {
		
					// Double-click detected
					int index = list.locationToIndex(evt.getPoint());

					GhidraClass gClass = classVec.get(index);
					classFeatureUI(gClass);
				}
			}
		});
		scrollPane.setViewportView(classList);

		contentPanel.add(scrollPane, BorderLayout.CENTER);

		JPanel searchPanel = new JPanel();
		JLabel searchLabel = new JLabel("Search: ");
		JTextArea searchBox = new JTextArea(1, 50);
		searchBox.addKeyListener(new KeyAdapter() {
            public void keyReleased(KeyEvent evt) {
                String newText = searchBox.getText();
				classVec.clear();
				table.getClassNamespaces().forEachRemaining(e->{
					if(e.getName().contains(newText)) {
						classVec.add(e);
					}
				});
				contentPanel.repaint();
            }
        });
		searchPanel.add(searchLabel, BorderLayout.WEST);
		searchPanel.add(searchBox, BorderLayout.CENTER);
		contentPanel.add(searchPanel, BorderLayout.SOUTH);

		frame.add(contentPanel);

		frame.setVisible(true);
	}

public class Builder {
	NativeClass toGen;
	public Builder() {
		toGen = new NativeClass();
	}
	public NativeClass build() {
		return toGen;
	}

	public Builder setName(String className) {
		toGen.setClassName(className);
		return this;
	}
}

public class NativeClass {
    private String className;
    private String nativeClassExtends;
    private Field[] fields;
    private Function[] functions;
    private Virtual[] virtuals;
    private String[] includes;

    public String getClassName() { return className; }
    public void setClassName(String value) { this.className = value; }

    public String getNativeClassExtends() { return nativeClassExtends; }
    public void setNativeClassExtends(String value) { this.nativeClassExtends = value; }

    public Field[] getFields() { return fields; }
    public void setFields(Field[] value) { this.fields = value; }

    public Function[] getFunctions() { return functions; }
    public void setFunctions(Function[] value) { this.functions = value; }

    public Virtual[] getVirtuals() { return virtuals; }
    public void setVirtuals(Virtual[] value) { this.virtuals = value; }

    public String[] getIncludes() { return includes; }
    public void setIncludes(String[] value) { this.includes = value; }
}
public class Field {
    private String name;
    private Offset offset;
    private Type type;

    public String getName() { return name; }
    public void setName(String value) { this.name = value; }

    public Offset getOffset() { return offset; }
    public void setOffset(Offset value) { this.offset = value; }

    public Type getType() { return type; }
    public void setType(Type value) { this.type = value; }
}
public class Offset {
    public Long integerValue;
    public String stringValue;
}
public class Type {
    private String typeName;
    private Offset typeSize;

    public String getTypeName() { return typeName; }
    public void setTypeName(String value) { this.typeName = value; }

    public Offset getTypeSize() { return typeSize; }
    public void setTypeSize(Offset value) { this.typeSize = value; }
}
public class Function {
    private String name;
    private String signature;
    private Parameter[] parameters;
    private String type;
    private String convention;
    private Boolean functionStatic;

    public String getName() { return name; }
    public void setName(String value) { this.name = value; }

    public String getSignature() { return signature; }
    public void setSignature(String value) { this.signature = value; }

    public Parameter[] getParameters() { return parameters; }
    public void setParameters(Parameter[] value) { this.parameters = value; }

    public String getType() { return type; }
    public void setType(String value) { this.type = value; }

    public String getConvention() { return convention; }
    public void setConvention(String value) { this.convention = value; }

    public Boolean getFunctionStatic() { return functionStatic; }
    public void setFunctionStatic(Boolean value) { this.functionStatic = value; }
}
public class Parameter {
    private String name;
    private String type;

    public String getName() { return name; }
    public void setName(String value) { this.name = value; }

    public String getType() { return type; }
    public void setType(String value) { this.type = value; }
}
public class Virtual {
    private String name;
    private Offset offset;
    private Parameter[] parameters;
    private String type;

    public String getName() { return name; }
    public void setName(String value) { this.name = value; }

    public Offset getOffset() { return offset; }
    public void setOffset(Offset value) { this.offset = value; }

    public Parameter[] getParameters() { return parameters; }
    public void setParameters(Parameter[] value) { this.parameters = value; }

    public String getType() { return type; }
    public void setType(String value) { this.type = value; }
}
}
