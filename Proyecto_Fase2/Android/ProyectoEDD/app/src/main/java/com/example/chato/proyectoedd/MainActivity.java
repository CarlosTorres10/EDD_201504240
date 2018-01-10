package com.example.chato.proyectoedd;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
//import android.view.View;
import android.view.View;
import android.widget.Button;
import android.view.View.OnClickListener;
import android.widget.TextView;


public class MainActivity extends AppCompatActivity implements OnClickListener{

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        Button btnMyButton = (Button) findViewById(R.id.button6);
        btnMyButton.setOnClickListener(this);
    }

    @Override
    public void onClick(View view) {
        TextView labelMensaje = (TextView) findViewById(R.id.TextSalida);
        labelMensaje.setText("Intente realizar android pero ya no pude realizar mas investigación :) :)");
    }
}
