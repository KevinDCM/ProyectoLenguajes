package com.example.demo;

import com.fasterxml.jackson.annotation.JsonProperty;

import javax.persistence.*;

@Entity
@Table(name = "Student")
@NamedStoredProcedureQuery(name = "Student.getAllStudents", procedureName = "SelectStudent")

@NamedStoredProcedureQuery(name = "Student.getStudentById", procedureName = "SelectStudentById",
        parameters = {
                @StoredProcedureParameter(mode = ParameterMode.IN, name = "Student_Id", type = Integer.class)}
)

@NamedStoredProcedureQuery(name = "Student.deleteStudentSP",procedureName = "DeleteStudentById",
        parameters = {
                @StoredProcedureParameter(mode = ParameterMode.IN, name = "Student_Id", type = Integer.class)}
)

@NamedStoredProcedureQuery(name = "Student.insertStudentSP", procedureName = "InsertStudent",
        parameters = {
                @StoredProcedureParameter(mode = ParameterMode.IN, name = "name", type = String.class),
                @StoredProcedureParameter(mode = ParameterMode.IN, name = "email", type = String.class),
                @StoredProcedureParameter(mode = ParameterMode.IN, name = "password", type = String.class)}
)

@NamedStoredProcedureQuery(name = "Student.updateStudentSP", procedureName = "UpdateStudentById",
        parameters = {
                @StoredProcedureParameter(mode = ParameterMode.IN, name = "Student_Id", type = Integer.class),
                @StoredProcedureParameter(mode = ParameterMode.IN, name = "name", type = String.class),
                @StoredProcedureParameter(mode = ParameterMode.IN, name = "email", type = String.class),
                @StoredProcedureParameter(mode = ParameterMode.IN, name = "password", type = String.class)}
)

public class Student {
    @JsonProperty
    private int StudentId;
    @JsonProperty
    @Column
    private String Name;
    @JsonProperty
    @Column
    private String Email;
    @JsonProperty
    @Column
    private String Password;

    public Student() {
    }

    public Student(int studentId, String name, String email, String password) {
        this.StudentId = studentId;
        this.Name = name;
        this.Email = email;
        this.Password = password;
    }

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    public int getStudentId() {
        return StudentId;
    }

    public void setStudentId(int studentId) {
        this.StudentId = studentId;
    }

    public String getName() {
        return Name;
    }

    public void setName(String name) {
        this.Name = name;
    }

    public String getEmail() {
        return Email;
    }

    public void setEmail(String email) {
        this.Email = email;
    }

    public String getPassword() {
        return Password;
    }

    public void setPassword(String password) {
        this.Password = password;
    }
}
