import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:tutor_me/src/colorpallete.dart';
import 'package:tutor_me/src/theme/themes.dart';

import '../../../services/models/globals.dart';

class TuteeActivity extends StatefulWidget {
  final Globals globals;
  const TuteeActivity({Key? key, required this.globals}) : super(key: key);

  @override
  State<StatefulWidget> createState() {
    return TuteeActivityState();
  }
}

class TuteeActivityState extends State<TuteeActivity> {
  @override
  Widget build(BuildContext context) {
    final provider = Provider.of<ThemeProvider>(context, listen: false);

    Color textColor;
    Color highLightColor;

    if (provider.themeMode == ThemeMode.dark) {
      textColor = colorWhite;
      highLightColor = colorLightBlueTeal;
    } else {
      textColor = colorDarkGrey;
      highLightColor = colorOrange;
    }

    return Material(
      child: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: <Widget>[
            Icon(
              Icons.notifications,
              size: MediaQuery.of(context).size.height * 0.15,
              color: highLightColor,
            ),
            Text(
              'No Activity found',
              style: TextStyle(
                color: textColor,
              ),
            )
          ],
        ),
      ),
    );
  }
}
