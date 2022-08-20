package io.github.disabledmallis.classbuilder;

import com.google.gson.Gson;
import com.google.gson.JsonObject;

import java.nio.file.Files;
import java.nio.file.Paths;

public class Main {
    public static void main(String[] args) {
        try {
            byte[] bytes = Files.readAllBytes(Paths.get("test.json"));
            String fileContent = new String(bytes);
            JsonObject parsedObject = new Gson().fromJson(fileContent, JsonObject.class);
        } catch(Exception ex) {
            ex.printStackTrace();
        }
    }
}