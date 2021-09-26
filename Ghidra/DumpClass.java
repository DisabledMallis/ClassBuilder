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

    public void run() throws Exception {
		selectClassUI();
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
}
